import React, { useEffect, Dispatch, createContext, PropsWithChildren, useReducer, useContext } from 'react';
import { FiefManagerState, FiefManagerAction, initialFiefManagerState, FiefManagerActionTypes, FiefManagerStatuses } from './types';
import { fiefManagerReducer } from './reducer';
import { getFief } from './actions';

type FiefManagerContextProps = {
  state: FiefManagerState;
  dispatch: Dispatch<FiefManagerAction>;
};

const FiefManagerContext = createContext<FiefManagerContextProps>({
  state: initialFiefManagerState,
  dispatch: () => initialFiefManagerState
});

export const FiefManagerProvider: React.FC<PropsWithChildren<{}>> = (props) => {
  const [state, dispatch] = useReducer(fiefManagerReducer, initialFiefManagerState);

  const loadFief = async (id: string) => {
    console.log('trigger');
    getFief(id)
    .then(response => {
      dispatch({ type: FiefManagerActionTypes.FIEFMANAGER_LOAD_FIEF_SUCCESS, fief: response.data });
    })
  }

  useEffect(() => {
    if (state.status !== FiefManagerStatuses.LOADED && state.fiefId === '' && state.gameSessionId !== '') {
      loadFief(state.gameSessionId);
    } else if (state.status !== FiefManagerStatuses.LOADED && state.fiefId !== '') {
      loadFief(state.fiefId);
    }
  }, [state.status, state.fiefId, state.gameSessionId, state])

  return <FiefManagerContext.Provider value={{ state, dispatch }} {...props} />;
}

export default function useFiefManagerService() {
  return useContext(FiefManagerContext);
}
