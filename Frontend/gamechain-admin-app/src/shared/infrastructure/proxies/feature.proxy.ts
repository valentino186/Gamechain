import { UpdateFeatureCommand } from './../models/requests/feature/update-feature-command.model';
import { CreateFeatureCommand } from './../models/requests/feature/create-feature-command.model';
import { authGamechainApi } from 'src/boot/axios';
import { FeatureResponse } from './../models/responses/feature-response.model';

const url = '/Feature';

export const useFeatureProxy = () => {
    function getFeatures() {
        return authGamechainApi.get<FeatureResponse[]>(url);
    }

    function createFeature(createFeatureCommand: CreateFeatureCommand) {
        return authGamechainApi.post<FeatureResponse>(url, createFeatureCommand);
    }

    function updateFeature(updateFeatureCommand: UpdateFeatureCommand) {
        return authGamechainApi.put<FeatureResponse>(url, updateFeatureCommand);
    }

    function deleteFeature(featureId: string) {
        return authGamechainApi.delete(`${url}/${featureId}`);
    }

    return {
        getFeatures,
        createFeature,
        updateFeature,
        deleteFeature
    }
}