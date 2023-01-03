import { Genre } from './../shared/core/entities/genre.model';
import { defineStore } from 'pinia';
import { reactive } from 'vue';

interface GenreState {
    genres: Genre[];
    loading: boolean;
}

export const useGenreStore = defineStore('genres', () => {
    const state = reactive<GenreState>({
        genres: [],
        loading: false
    });

    function setGenres(genres: Genre[]) {
        state.genres = genres;
    }

    function setLoading(status: boolean) {
        state.loading = status;
    }

    function createGenre(genre: Genre) {
        state.genres.push(genre);
    }

    function updateGenre(genre: Genre) {
        const genreIndex = state.genres.findIndex(x => x.id === genre.id);
        state.genres[genreIndex] = genre;
    }

    return {
        state,
        setGenres,
        setLoading,
        createGenre,
        updateGenre
    }
})