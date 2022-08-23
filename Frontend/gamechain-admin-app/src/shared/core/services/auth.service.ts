import { LoginRequest } from './../../infrastructure/models/requests/auth/login-request.model';
import { useAuthProxy } from './../../infrastructure/proxies/auth.proxy';

export const useAuthService = () => {
    const authProxy = useAuthProxy();

    async function login(loginRequest: LoginRequest) {
        try {
            const result = await authProxy.login(loginRequest);
            console.log(result.data)
        }
        catch (error) {
            console.log('An error has occured while trying to login.')
        }
        finally {
            // loading
        }
    }

    return {
        login
    }
}