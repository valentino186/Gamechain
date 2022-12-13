import { useAuthStore } from './../../../stores/auth.store';
import { useAuthProxy } from './../../infrastructure/proxies/auth.proxy';
import { LoginRequest } from '../../infrastructure/models/requests/auth/login-query.model';

export const useAuthService = () => {
    const authProxy = useAuthProxy();
    const authStore = useAuthStore();

    async function login(loginRequest: LoginRequest) {
        try {
            authStore.setLoading(true);

            const result = await authProxy.login(loginRequest);

            authStore.setToken(result.data.token);
        }
        catch (error) {
            console.log('An error has occured while trying to login.')
        }
        finally {
            authStore.setLoading(false);
        }
    }

    return {
        login
    }
}