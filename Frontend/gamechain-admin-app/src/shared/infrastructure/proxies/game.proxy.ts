import { GameResponse } from './../models/responses/game-response.model';
import { authGamechainApi } from 'src/boot/axios';

const url = '/Game';

export const useGameProxy = () => {
    function getPublisherGames(publisherId: string) {
        return authGamechainApi.get<GameResponse[]>(`${url}/Publisher/${publisherId}`);
    }

    return {
        getPublisherGames
    }
}