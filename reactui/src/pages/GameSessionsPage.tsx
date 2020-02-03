import React, { useEffect } from 'react';
import { connect } from 'react-redux';
import { Table, Container, Button } from 'reactstrap';
import { ApplicationState } from '../store';
import { GameSession } from '../common/models/GameSession';
import { setGameSessionId } from '../store/fiefmanager/actions';
import {
  fetchGameSessionsRequest,
  createGameSessionCommand,
  deleteGameSessionCommand
} from '../store/gamesessions/actions';
import { history } from '..';
import { IdObject } from '../store/gamesessions/types';

interface PropsFromState {
  data: GameSession[];
  loading: boolean;
  errors?: string;
}

interface PropsFromDispatch {
  fetchGameSessionsRequest: typeof fetchGameSessionsRequest;
  setGameSessionId: typeof setGameSessionId;
  createGameSessionCommand: typeof createGameSessionCommand;
  deleteGameSessionCommand: typeof deleteGameSessionCommand;
}

type AllProps = PropsFromState & PropsFromDispatch;

const GameSessionsPage: React.FC<AllProps> = props => {
  const {
    createGameSessionCommand,
    fetchGameSessionsRequest,
    deleteGameSessionCommand,
    setGameSessionId
  } = props;

  useEffect(() => {
    fetchGameSessionsRequest();
  }, [fetchGameSessionsRequest]);

  const handleRowClick = (id: string) => {
    setGameSessionId(id);
    history.push('/fiefmanager');
  };

  const handleCreateButtonClick = () => {
    createGameSessionCommand();
  };

  const handleDeleteButtonClick = (id: string) => {
    let idObj: IdObject = {
      id: id
    };
    deleteGameSessionCommand(idObj);
  };

  const { data } = props;
  return (
    <Container>
      <Table hover>
        <thead>
          <tr>
            <th>Session</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {data.map(session => (
            <tr key={session.gameSessionId}>
              <td onClick={() => handleRowClick(session.gameSessionId)}>
                {session.name}
              </td>
              <td>
                <Button
                  onClick={() => handleDeleteButtonClick(session.gameSessionId)}
                >
                  Tabort
                </Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
      <Button onClick={() => handleCreateButtonClick()}>
        lägg till session
      </Button>
    </Container>
  );
};

const mapStateToProps = ({ gs }: ApplicationState) => ({
  loading: gs.loading,
  errors: gs.errors,
  data: gs.data
});

const mapDispatchToProps = {
  fetchGameSessionsRequest: fetchGameSessionsRequest,
  setGameSessionId: setGameSessionId,
  createGameSessionCommand: createGameSessionCommand,
  deleteGameSessionCommand: deleteGameSessionCommand
};

export default connect(mapStateToProps, mapDispatchToProps)(GameSessionsPage);
