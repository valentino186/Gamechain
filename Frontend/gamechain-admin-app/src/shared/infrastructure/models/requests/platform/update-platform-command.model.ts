import { CreatePlatformCommand } from './create-platform-command.model';

export interface UpdatePlatformCommand extends CreatePlatformCommand {
    id: string;
}