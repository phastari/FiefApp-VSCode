import { useState, useEffect } from "react";
import axios from "../../common/api/apiClient";
import { ISteward, IStewards } from "./types";
import { StewardsService } from "./states";

const useStewardsService = () => {
    const [result, setResult] = useState<StewardsService<ISteward[]>>({
        status: 'loading'
    });

    useEffect(() => {
        if (result.status !== 'loaded') {
            setTimeout(function () {
                axios.get<IStewards>('/stewards/getstewards')
                .then(response => setResult({ status: 'loaded', payload: response.data.Stewards }))
                .catch(error => setResult({ status: 'error', error }));
            }, 1000);
            
        }
    }, [result.status]);

    return result;
}

export default useStewardsService;