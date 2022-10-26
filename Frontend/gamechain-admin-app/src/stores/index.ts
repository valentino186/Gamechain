import { store } from 'quasar/wrappers';
import { createPinia } from 'pinia';
import { createORM } from 'pinia-orm';
import piniaPluginPersistedstate from 'pinia-plugin-persistedstate';

export default store((/* { ssrContext } */) => {
  const pinia = createPinia();

  // You can add Pinia plugins here
  pinia.use(createORM());
  pinia.use(piniaPluginPersistedstate);

  return pinia;
});