window.getDimensions = () => ({
    width: window.innerWidth,
    height: window.innerHeight
});

window.portfolio = {
    getCulture(supported) {
        const preferred = [localStorage.getItem("portfolio.culture"), ...navigator.languages];
        for (const language of preferred) {
            const culture = language?.split("-")[0].toLowerCase();
            if (supported.includes(culture)) {
                return culture;
            }
        }
        return "en";
    },
    setCulture(culture) {
        localStorage.setItem("portfolio.culture", culture);
    },
    applyCulture(culture, messages) {
        document.documentElement.lang = culture;
        document.querySelector("#blazor-error-ui .message").textContent = messages.error;
        document.querySelector("#blazor-error-ui .reload").textContent = messages.reload;
        document.querySelector("#blazor-error-ui .dismiss").setAttribute("aria-label", messages.dismiss);
    },
    resizeHandler: null,
    startResizeListener(dotnetHelper) {
        this.stopResizeListener();
        this.resizeHandler = () => dotnetHelper.invokeMethodAsync("UseWindow");
        window.addEventListener("resize", this.resizeHandler);
    },
    stopResizeListener() {
        if (this.resizeHandler) {
            window.removeEventListener("resize", this.resizeHandler);
            this.resizeHandler = null;
        }
    }
};
