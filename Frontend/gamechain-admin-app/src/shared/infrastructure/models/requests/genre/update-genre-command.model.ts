import { CreateGenreCommand } from './create-genre-command.model';

export interface UpdateGenreCommand extends CreateGenreCommand {
    id: string;
}