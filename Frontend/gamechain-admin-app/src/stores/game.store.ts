import { reactive } from 'vue';
import { defineStore } from 'pinia';
import { Game } from './../shared/core/entities/game.model';

interface GameState {
    games: Game[];
    loading: boolean;
}

export const useGameStore = defineStore('games', () => {
    const state = reactive<GameState>({
        games: [],
        loading: false
    });

    function setGames(games: Game[]) {
        state.games = games;
    }

    function setLoading(status: boolean) {
        state.loading = status;
    }

    return {
        state,
        setGames,
        setLoading
    }
})