import { UpdatePlatformCommand } from './../../infrastructure/models/requests/platform/update-platform-command.model';
import { CreatePlatformCommand } from './../../infrastructure/models/requests/platform/create-platform-command.model';
import { usePlatformProxy } from './../../infrastructure/proxies/platform.proxy';
import { useNotify } from './../../components/notify/useNotify';
import { usePlatformStore } from "src/stores/platform.store"

export const usePlatformService = () => {
    const platformProxy = usePlatformProxy();
    const platformStore = usePlatformStore();
    const notify = useNotify();

    async function getPlatforms() {
        try {
            platformStore.setLoading(true);

            const response = await platformProxy.getPlatforms();

            platformStore.setPlatforms(response.data);
        }
        catch {
            notify.negative('An error has occured while trying to fetch data.');
        }
        finally {
            platformStore.setLoading(false);
        }
    }

    async function createPlatform(createPlatformCommand: CreatePlatformCommand) {
        try {
            platformStore.setLoading(true);

            const response = await platformProxy.createPlatform(createPlatformCommand);

            platformStore.createPlatform(response.data);

            notify.success('Platform created successfully!');
        }
        catch {
            notify.negative('An error has occured while trying to create Platform');
        }
        finally {
            platformStore.setLoading(false);
        }
    }

    async function updatePlatform(updatePlatformCommand: UpdatePlatformCommand) {
        try {
            platformStore.setLoading(true);

            const response = await platformProxy.updatePlatform(updatePlatformCommand);

            platformStore.updatePlatform(response.data);

            notify.success('Platform updated successfully!');
        }
        catch {
            notify.negative('An error has occured while trying to update Platform');
        }
        finally {
            platformStore.setLoading(false);
        }
    }

    async function deletePlatform(platformId: string) {
        try {
            platformStore.setLoading(true);

            await platformProxy.deletePlatform(platformId);

            platformStore.deletePlatform(platformId);

            notify.success('Platform deleted successfully!');
        }
        catch {
            notify.negative('An error has occured while trying to delete Platform');
        }
        finally {
            platformStore.setLoading(false);
        }
    }

    return {
        getPlatforms,
        createPlatform,
        updatePlatform,
        deletePlatform
    }
}