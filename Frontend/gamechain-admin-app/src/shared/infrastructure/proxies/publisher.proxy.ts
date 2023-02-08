import { UpdatePublisherCommand } from '../models/requests/publisher/update-publisher-command.model';
import { CreatePublisherCommand } from '../models/requests/publisher/create-publisher-command.model';
import { PublisherResponse } from './../models/responses/publisher-response.model';
import { authGamechainApi } from "src/boot/axios"

const url = '/Publisher';

export const usePublisherProxy = () => {
    function getPublishers() {
        return authGamechainApi.get<PublisherResponse[]>(url);
    }

    function getPublisherById(publisherId: string) {
        return authGamechainApi.get<PublisherResponse>(`${url}/${publisherId}`);
    }

    function createPublisher(createPublisherCommand: CreatePublisherCommand) {
        return authGamechainApi.post<PublisherResponse>(url, createPublisherCommand);
    }

    function updatePublisher(updatePublisherCommand: UpdatePublisherCommand) {
        return authGamechainApi.put<PublisherResponse>(url, updatePublisherCommand);
    }

    function deletePublisher(publisherId: string) {
        return authGamechainApi.delete(`${url}/${publisherId}`);
    }

    return {
        getPublishers,
        getPublisherById,
        createPublisher,
        updatePublisher,
        deletePublisher
    }
}