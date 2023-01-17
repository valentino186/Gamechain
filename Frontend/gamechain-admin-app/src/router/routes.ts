import MainLayout from "layouts/MainLayout.vue";
import { RouteRecordRaw } from "vue-router";
import { loginRoutes } from "src/features/login/login.routes";
import { featureRoutes } from "./../features/feature/feature.routes";
import { genreRoutes } from './../features/genre/genre.routes';
import { platformRoutes } from './../features/platform/platform.routes';
import { publisherRoutes } from './../features/publisher/publisher.routes';

const routes: RouteRecordRaw[] = [
  {
    path: "/",
    redirect: "/features",
  },
  ...loginRoutes,
  {
    path: "/",
    component: MainLayout,
    children: [
      ...featureRoutes,
      ...genreRoutes,
      ...platformRoutes,
      ...publisherRoutes
    ],
    meta: {
      requiresAuth: true
    }
  },
];

export default routes;
