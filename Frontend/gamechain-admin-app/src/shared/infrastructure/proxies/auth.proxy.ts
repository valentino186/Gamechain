import { gamechainApi } from 'src/boot/axios';
import { LoginResponse } from '../models/responses/login-response.model';
import { LoginRequest } from '../models/requests/auth/login-query.model';

export const useAuthProxy = () => {
    function login(loginRequest: LoginRequest) {
        return gamechainApi.post<LoginResponse>('/Auth/Login', loginRequest);
    }

    return {
        login
    }
}