import { useQuasar } from "quasar"

export const useNotify = () => {
    const $q = useQuasar();
    const timeout = 3000;

    function success(message: string) {
        $q.notify({
            message: message,
            color: 'positive',
            timeout: timeout
        })
    }

    function negative(message: string) {
        $q.notify({
            message: message,
            color: 'negative',
            timeout: timeout
        })
    }

    return {
        success,
        negative
    }
}