import React, { useEffect, Dispatch, createContext, PropsWithChildren, useReducer, useContext } from 'react';
import { FiefManagerState, FiefManagerAction, initialFiefManagerState, FiefManagerActionTypes, FiefManagerStatuses } from './types';
import { fiefManagerReducer } from './reducer';
import { initializeFiefManager, getFief } from './actions';

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

  const initializeLists = async (id: string) => {
    initializeFiefManager(id)
    .then(response => {
      dispatch({ type: FiefManagerActionTypes.FIEFMANAGER_INITIALIZE_SUCCESS, init: response.data });
    })
  }

  const loadFief = async (id: string) => {
    getFief(id)
    .then(response => {
      dispatch({ type: FiefManagerActionTypes.FIEFMANAGER_LOAD_FIEF_SUCCESS, fief: response.data });
    })
  }

  useEffect(() => {
    if (state.status === FiefManagerStatuses.INITIALIZING && state.gameSessionId !== '') {
      initializeLists(state.gameSessionId);
    } else if (state.status === FiefManagerStatuses.INITIALIZED && state.fiefId !== '') {
      loadFief(state.fiefId);
    }
  }, [state])

  return <FiefManagerContext.Provider value={{ state, dispatch }} {...props} />;
}

export default function useFiefManagerService() {
  return useContext(FiefManagerContext);
}
