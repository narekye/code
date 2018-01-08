import { platformBrowserDynamic } from "@angular/platform-browser-dynamic";
import { AppModule } from './app/app.module';
var platform = platformBrowserDynamic();
platform.bootstrapModule(AppModule);
if (module.hot) {
    module.hot.accept();
    module.hot.dispose(function () {
        var oldRootItem = document.querySelector('app-root');
        var newRootItem = document.createElement('app-root');
        oldRootItem.parentNode.insertBefore(newRootItem, oldRootItem);
        platform.destroy();
    });
}
//# sourceMappingURL=main.js.map