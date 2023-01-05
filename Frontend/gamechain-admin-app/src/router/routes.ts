import MainLayout from "layouts/MainLayout.vue";
import { RouteRecordRaw } from "vue-router";
import { loginRoutes } from "src/features/login/login.routes";
import { genreRoutes } from './../features/genre/genre.routes';
import { platformRoutes } from './../features/platform/platform.routes';
import { publisherRoutes } from './../features/publisher/publisher.routes';

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
      ...genreRoutes,
      ...platformRoutes,
      ...publisherRoutes,
    ],
    meta: {
      requiresAuth: true
    }
  },
];

export default routes;
