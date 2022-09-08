import { RouteRecordRaw } from "vue-router";
import MainLayout from "layouts/MainLayout.vue";
import PublishersPage from "src/features/publisher/pages/PublishersPage.vue";
import { loginRoutes } from "src/features/login/login.routes";

const routes: RouteRecordRaw[] = [
  {
    path: "/",
    redirect: "/app/publishers",
  },
  ...loginRoutes,
  {
    path: "/app",
    component: MainLayout,
    children: [
      {
        path: "publishers",
        component: PublishersPage,
      }
    ],
    meta: {
      requiresAuth: true
    }
  },
];

export default routes;
