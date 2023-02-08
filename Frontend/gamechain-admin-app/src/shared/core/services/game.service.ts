import { useNotify } from './../../components/notify/useNotify';
import { useGameStore } from './../../../stores/game.store';
import { useGameProxy } from './../../infrastructure/proxies/game.proxy';

export const useGameService = () => {
    const gameProxy = useGameProxy();
    const gameStore = useGameStore();
    const notify = useNotify();

    async function getPublisherGames(publisherId: string) {
        try {
            gameStore.setLoading(true);

            const response = await gameProxy.getPublisherGames(publisherId);

            gameStore.setGames(response.data);
        }
        catch {
            notify.negative('An error has occured while trying to fetch data.');
        }
        finally {
            gameStore.setLoading(false);
        }
    }

    return {
        getPublisherGames
    }
}