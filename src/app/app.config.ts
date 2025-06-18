import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';

import { provideRouter, withEnabledBlockingInitialNavigation, withInMemoryScrolling } from '@angular/router';
import { routes } from './app.routes';

import { provideTablerIcons } from "angular-tabler-icons"
import * as TableIcons from 'angular-tabler-icons/icons';


export const appConfig: ApplicationConfig = {
  	providers: [
		provideZoneChangeDetection({ eventCoalescing: true }),
		provideRouter(routes, withEnabledBlockingInitialNavigation(), withInMemoryScrolling({
			anchorScrolling: 'enabled'
		})),
		provideTablerIcons(TableIcons),
	]
};
