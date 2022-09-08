import { defineStore } from "pinia";
import { reactive } from "vue";

export const useAuthStore = defineStore("auth", () => {
    const state = reactive({
      loading: false,
      token: "",
    });

    function setLoading(status: boolean) {
      state.loading = status;
    }

    function setToken(token: string) {
      state.token = token;
    }

    return {
      state,
      setLoading,
      setToken,
    };
  },
  {
    persist: true,
  }
);
