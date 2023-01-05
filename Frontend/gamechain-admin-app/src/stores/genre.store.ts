import { GenreFilterForm } from './../shared/infrastructure/models/filters/genre-filter-form.model';
import { Genre } from './../shared/core/entities/genre.model';
import { defineStore } from 'pinia';
import { reactive } from 'vue';

interface GenreState {
    genres: Genre[];
    loading: boolean;
    filters: GenreFilterForm
}

export const useGenreStore = defineStore('genres', () => {
    const state = reactive<GenreState>({
        genres: [],
        loading: false,
        filters: {
            name: ''
        }
    });

    function getGenres() {
        return state.genres.filter(x => x.name.toLowerCase().includes(state.filters.name.toLowerCase()));
    }

    function setGenres(genres: Genre[]) {
        state.genres = genres;
    }

    function setLoading(status: boolean) {
        state.loading = status;
    }

    function setFilters(genreFilterForm: GenreFilterForm) {
        Object.assign(state.filters, genreFilterForm);
    }

    function createGenre(genre: Genre) {
        state.genres.push(genre);
    }

    function updateGenre(genre: Genre) {
        const genreIndex = state.genres.findIndex(x => x.id === genre.id);
        state.genres[genreIndex] = genre;
    }

    function deleteGenre(genreId: string) {
        state.genres = state.genres.filter(x => x.id !== genreId);
    }

    return {
        state,
        getGenres,
        setGenres,
        setLoading,
        setFilters,
        createGenre,
        updateGenre,
        deleteGenre
    }
})