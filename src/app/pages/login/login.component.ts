import { Component, effect, inject } from "@angular/core";
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ButtonComponent } from "../../shared/components/button/button.component";
import { Router } from "@angular/router";
import { AuthService } from "../../core/services/auth/auth.service";
import { AppRoutes } from "../../core/constants/app-routes";
import { LogoComponent } from "../../shared/components/logo/logo.component";
import { InputComponent } from "../../shared/components/input/input.component";

@Component({
	selector: "login",
	templateUrl: "./login.component.html",
	standalone: true,
	imports: [
		ReactiveFormsModule,
		ButtonComponent,
		LogoComponent,
		InputComponent
	],
})
export class LoginComponent {

	readonly auth = inject(AuthService);
	readonly router = inject(Router);
	readonly form: FormGroup;

	constructor(private fb: FormBuilder) {
		this.auth.tryCookiesAuth();
		effect(() => this.auth.user() && this.router.navigate([AppRoutes.DASHBOARD]))

		this.form = this.fb.group({
			userIdentifier: ['', [Validators.required]],
			password: ['', [Validators.required]],
		});
	}

	async submit() {
		await this.auth.login(this.form.value);
	}
}
