import { platformBrowserDynamic } from "@angular/platform-browser-dynamic";
import { AppModule } from './app/app.module';
const platform = platformBrowserDynamic();

platform.bootstrapModule(AppModule);

if (module.hot) {
    module.hot.accept();
    module.hot.dispose(() => {
        const oldRootItem = document.querySelector('app-root');
        const newRootItem = document.createElement('app-root');
        oldRootItem!.parentNode!.insertBefore(newRootItem, oldRootItem);
        platform.destroy();
    });
}