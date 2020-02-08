import { useState, useEffect } from "react";
import axios from "../../common/api/authenticationApi";
import { IIndustries, IIndustry } from "./types";
import { IndustriesService } from "./states";

const useIndustriesService = () => {
    const [result, setResult] = useState<IndustriesService<IIndustry[]>>({
        status: 'loading'
    });

    useEffect(() => {
        if (result.status !== 'loaded') {
            setTimeout(function () {
                axios.get<IIndustries>('/industries/getindustries')
                .then(response => setResult({ status: 'loaded', payload: response.data.Industries }))
                .catch(error => setResult({ status: 'error', error }));
            }, 1000);
            
        }
    }, [result.status]);

    return result;
}

export default useIndustriesService;