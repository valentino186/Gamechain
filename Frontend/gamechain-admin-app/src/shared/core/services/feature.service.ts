import { UpdateFeatureCommand } from './../../infrastructure/models/requests/feature/update-feature-command.model';
import { CreateFeatureCommand } from './../../infrastructure/models/requests/feature/create-feature-command.model';
import { useNotify } from './../../components/notify/useNotify';
import { useFeatureStore } from './../../../stores/feature.store';
import { useFeatureProxy } from './../../infrastructure/proxies/feature.proxy';

export const useFeatureService = () => {
    const featureProxy = useFeatureProxy();
    const featureStore = useFeatureStore();
    const notify = useNotify();

    async function getFeatures() {
        try {
            featureStore.setLoading(true);

            const response = await featureProxy.getFeatures();

            featureStore.setFeatures(response.data);
        }
        catch {
            notify.negative('An error has occured while trying to fetch data.');
        }
        finally {
            featureStore.setLoading(false);
        }
    }

    async function createFeature(createFeatureCommand: CreateFeatureCommand) {
        try {
            featureStore.setLoading(true);

            const response = await featureProxy.createFeature(createFeatureCommand);

            featureStore.createFeature(response.data);

            notify.success('Feature created successfully!');
        }
        catch {
            notify.negative('An error has occured while trying to create Feature');
        }
        finally {
            featureStore.setLoading(false);
        }
    }

    async function updateFeature(updateFeatureCommand: UpdateFeatureCommand) {
        try {
            featureStore.setLoading(true);

            const response = await featureProxy.updateFeature(updateFeatureCommand);

            featureStore.updateFeature(response.data);

            notify.success('Feature updated successfully!');
        }
        catch {
            notify.negative('An error has occured while trying to update Feature');
        }
        finally {
            featureStore.setLoading(false);
        }
    }

    async function deleteFeature(featureId: string) {
        try {
            featureStore.setLoading(true);

            await featureProxy.deleteFeature(featureId);

            featureStore.deleteFeature(featureId);

            notify.success('Feature deleted successfully!');
        }
        catch {
            notify.negative('An error has occured while trying to delete Feature');
        }
        finally {
            featureStore.setLoading(false);
        }
    }

    return {
        getFeatures,
        createFeature,
        updateFeature,
        deleteFeature
    }
}