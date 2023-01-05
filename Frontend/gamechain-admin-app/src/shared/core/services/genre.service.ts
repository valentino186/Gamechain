import { UpdateGenreCommand } from './../../infrastructure/models/requests/genre/update-genre-command.model';
import { CreateGenreCommand } from './../../infrastructure/models/requests/genre/create-genre-command.model';
import { useNotify } from './../../components/notify/useNotify';
import { useGenreProxy } from './../../infrastructure/proxies/genre.proxy';
import { useGenreStore } from './../../../stores/genre.store';

export const useGenreService = () => {
    const genreProxy = useGenreProxy();
    const genreStore = useGenreStore();
    const notify = useNotify();

    async function getGenres() {
        try {
            genreStore.setLoading(true);

            const response = await genreProxy.getGenres();

            genreStore.setGenres(response.data);
        }
        catch {
            notify.negative('An error has occured while trying to fetch data.');
        }
        finally {
            genreStore.setLoading(false);
        }
    }

    async function createGenre(createGenreCommand: CreateGenreCommand) {
        try {
            genreStore.setLoading(true);

            const response = await genreProxy.createGenre(createGenreCommand);

            genreStore.createGenre(response.data);

            notify.success('Genre created successfully!');
        }
        catch {
            notify.negative('An error has occured while trying to create Genre');
        }
        finally {
            genreStore.setLoading(false);
        }
    }

    async function updateGenre(updateGenreCommand: UpdateGenreCommand) {
        try {
            genreStore.setLoading(true);

            const response = await genreProxy.updateGenre(updateGenreCommand);

            genreStore.updateGenre(response.data);

            notify.success('Genre updated successfully!');
        }
        catch {
            notify.negative('An error has occured while trying to update Genre');
        }
        finally {
            genreStore.setLoading(false);
        }
    }

    async function deleteGenre(genreId: string) {
        try {
            genreStore.setLoading(true);

            await genreProxy.deleteGenre(genreId);

            genreStore.deleteGenre(genreId);

            notify.success('Genre deleted successfully!');
        }
        catch {
            notify.negative('An error has occured while trying to delete Genre');
        }
        finally {
            genreStore.setLoading(false);
        }
    }

    return {
        getGenres,
        createGenre,
        updateGenre,
        deleteGenre
    }
}