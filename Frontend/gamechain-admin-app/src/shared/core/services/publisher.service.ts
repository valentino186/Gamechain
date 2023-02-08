import { CreatePublisherCommand } from 'src/shared/infrastructure/models/requests/publisher/create-publisher-command.model';
import { UpdatePublisherCommand } from '../../infrastructure/models/requests/publisher/update-publisher-command.model';
import { usePublisherProxy } from './../../infrastructure/proxies/publisher.proxy';
import { usePublisherStore } from './../../../stores/publisher.store';
import { useNotify } from './../../components/notify/useNotify';

export const usePublisherService = () => {
    const publisherProxy = usePublisherProxy();
    const publisherStore = usePublisherStore();
    const notify = useNotify();

    async function getPublishers() {
        try {
            publisherStore.setLoading(true);
    
            const response = await publisherProxy.getPublishers();

            publisherStore.setPublishers(response.data);
        }
        catch {
            notify.negative('An error has occured while trying to fetch data.');
        }
        finally {
            publisherStore.setLoading(false);
        }
    }

    async function getPublisherById(publisherId: string) {
        try {
            publisherStore.setLoading(true);

            const response = await publisherProxy.getPublisherById(publisherId);

            publisherStore.setPublisher(response.data);
        }
        catch {
            notify.negative('An error has occured while trying to fetch data.');
        }
        finally {
            publisherStore.setLoading(false);
        }
    }

    async function createPublisher(createPublisherRequest: CreatePublisherCommand) {
        try {
            publisherStore.setLoading(true);

            const response = await publisherProxy.createPublisher(createPublisherRequest);

            publisherStore.createPublisher(response.data);

            notify.success('Publisher created successfully!');
        }
        catch {
            notify.negative('An error has occured while trying to create Publisher.');
        }
        finally {
            publisherStore.setLoading(false);
        }
    }

    async function updatePublisher(updatePublisherRequest: UpdatePublisherCommand) {
        try {
            publisherStore.setLoading(true);

            const response = await publisherProxy.updatePublisher(updatePublisherRequest);

            publisherStore.updatePublisher(response.data);

            notify.success('Publisher updated successfully!');
        }
        catch {
            notify.negative('An error has occured while trying to update Publisher.');
        }
        finally {
            publisherStore.setLoading(false);
        }
    }

    async function deletePublisher(publisherId: string) {
        try {
            publisherStore.setLoading(true);

            await publisherProxy.deletePublisher(publisherId);

            publisherStore.deletePublisher(publisherId);

            notify.success('Publisher deleted successfully!');
        }
        catch {
            notify.negative('An error has occured while trying to delete Publisher.');
        }
        finally {
            publisherStore.setLoading(false);
        }
    }

    return {
        getPublishers,
        getPublisherById,
        createPublisher,
        updatePublisher,
        deletePublisher
    }
}