import { CreateFeatureCommand } from './create-feature-command.model';

export interface UpdateFeatureCommand extends CreateFeatureCommand {
    id: string;
}