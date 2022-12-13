import MainLayout from "layouts/MainLayout.vue";
import { RouteRecordRaw } from "vue-router";
import { loginRoutes } from "src/features/login/login.routes";
import { publisherRoutes } from './../features/publisher/publisher.routes';
import { platformRoutes } from './../features/platform/platform.routes';

const routes: RouteRecordRaw[] = [
  {
    path: "/",
    redirect: "/publishers",
  },
  ...loginRoutes,
  {
    path: "/",
    component: MainLayout,
    children: [
      ...publisherRoutes,
      ...platformRoutes
    ],
    meta: {
      requiresAuth: true
    }
  },
];

export default routes;
