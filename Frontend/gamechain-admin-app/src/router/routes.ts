import { RouteRecordRaw } from "vue-router";
import MainLayout from "layouts/MainLayout.vue";
import PublishersPage from "src/modules/publisher/pages/PublishersPage.vue";
import LoginPage from "src/modules/login/pages/LoginPage.vue";

const routes: RouteRecordRaw[] = [
  {
    path: "/",
    redirect: "/login",
  },
  {
    path: "/login",
    component: LoginPage
  },
  {
    path: "/app",
    component: MainLayout,
    children: [
      {
        path: "publishers",
        component: PublishersPage,
      }
    ],
  },
];

export default routes;
