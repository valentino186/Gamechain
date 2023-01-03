import { UpdateGenreCommand } from './../models/requests/genre/update-genre-command.model';
import { CreateGenreCommand } from './../models/requests/genre/create-genre-command.model';
import { GenreResponse } from './../models/responses/genre-response.model';
import { authGamechainApi } from 'src/boot/axios';

const url = '/Genre';

export const useGenreProxy = () => {
    function getGenres() {
        return authGamechainApi.get<GenreResponse[]>(url);
    }

    function createGenre(createGenreCommand: CreateGenreCommand) {
        return authGamechainApi.post<GenreResponse>(url, createGenreCommand);
    }

    function updateGenre(updateGenreCommand: UpdateGenreCommand) {
        return authGamechainApi.put<GenreResponse>(url, updateGenreCommand);
    }

    return {
        getGenres,
        createGenre,
        updateGenre
    }
}