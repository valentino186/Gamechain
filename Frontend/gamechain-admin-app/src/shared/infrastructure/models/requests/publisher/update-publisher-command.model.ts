import { CreatePublisherCommand } from 'src/shared/infrastructure/models/requests/publisher/create-publisher-command.model';

export interface UpdatePublisherCommand extends CreatePublisherCommand {
    id: string;
}