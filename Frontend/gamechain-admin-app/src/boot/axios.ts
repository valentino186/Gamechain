import { boot } from 'quasar/wrappers';
import axios, { AxiosInstance } from 'axios';
import { useAuthStore } from './../stores/auth.store';

declare module '@vue/runtime-core' {
  interface ComponentCustomProperties {
    $axios: AxiosInstance;
  }
}

// Be careful when using SSR for cross-request state pollution
// due to creating a Singleton instance here;
// If any client changes this (global) instance, it might be a
// good idea to move this instance creation inside of the
// "export default () => {}" function below (which runs individually
// for each client)
const gamechainApi = axios.create({ 
  baseURL: 'https://localhost:7063/api'
});

const authGamechainApi = axios.create({ 
  baseURL: 'https://localhost:7063/api'
});

export default boot(({ app, store , router}) => {
  // for use inside Vue files (Options API) through this.$axios and this.$api
  const authStore = useAuthStore(store);

  authGamechainApi.interceptors.request.use(
    config => {
      const token = authStore.state.token;
  
      if (token)
        config.headers.Authorization = `Bearer ${token}`;
      else
        config.headers.Authorization = null;
  
      return config;
    }
  )
  
  authGamechainApi.interceptors.response.use(
    ok => ok,
    error => {
      if (error.reponse.status === 401) {
        authStore.setToken('');
        router.push({ path: '/login' })
      }
    }
  )

  app.config.globalProperties.$axios = axios;
  // ^ ^ ^ this will allow you to use this.$axios (for Vue Options API form)
  //       so you won't necessarily have to import axios in each vue file

  app.config.globalProperties.$api = authGamechainApi;
  // ^ ^ ^ this will allow you to use this.$api (for Vue Options API form)
  //       so you can easily perform requests against your app's API
});

export { 
  authGamechainApi,
  gamechainApi
};
