import '../polyfills';

import { platformBrowser } from '@angular/platform-browser';
import { enableProdMode } from '@angular/core';

import { AppModule } from './app.module';

enableProdMode();

platformBrowser().bootstrapModule(AppModule);