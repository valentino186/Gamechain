import { useAuthStore } from './../../../stores/auth.store';

export function checkToken(to: any, from: any, next: any) {
    const authStore = useAuthStore();
    if (authStore.state.token) {
        next('/')
    }
    else {
        next();
    }
}