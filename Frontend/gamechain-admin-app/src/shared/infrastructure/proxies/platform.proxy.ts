import { UpdatePlatformCommand } from './../models/requests/platform/update-platform-command.model';
import { CreatePlatformCommand } from './../models/requests/platform/create-platform-command.model';
import { authGamechainApi } from 'src/boot/axios';
import { PlatformResponse } from '../models/responses/platform-response.model';

const url = '/Platform';

export const usePlatformProxy = () => {
    function getPlatforms() {
        return authGamechainApi.get<PlatformResponse[]>(url);
    }

    function createPlatform(createPlatformCommand: CreatePlatformCommand) {
        return authGamechainApi.post<PlatformResponse>(url, createPlatformCommand);
    }

    function updatePlatform(updatePlatformCommand: UpdatePlatformCommand) {
        return authGamechainApi.put(url, updatePlatformCommand);
    }

    function deletePlatform(platformId: string) {
        return authGamechainApi.delete(`${url}/${platformId}`);
    }

    return {
        getPlatforms,
        createPlatform,
        updatePlatform,
        deletePlatform
    }
}