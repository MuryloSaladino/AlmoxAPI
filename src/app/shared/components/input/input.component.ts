import { Component, Input, forwardRef } from "@angular/core";
import { ControlValueAccessor, NG_VALUE_ACCESSOR, ReactiveFormsModule } from "@angular/forms";
import { v4 as uuid } from "uuid";

@Component({
    selector: "app-input",
    templateUrl: "./input.component.html",
    styleUrl: "./input.component.css",
    standalone: true,
    imports: [ReactiveFormsModule],
    providers: [{
        provide: NG_VALUE_ACCESSOR,
        useExisting: forwardRef(() => InputComponent),
        multi: true
    }]
})
export class InputComponent implements ControlValueAccessor {
    @Input() id: string = uuid();
    @Input() placeholder: string = "";
    @Input() label: string = "";
    @Input() helperText: string = "";
    @Input() type: string = "text";
    @Input() disabled: boolean = false;
    @Input() className: string = "";
    @Input() error: boolean = false;

    value: string = "";

    onChange = (_: any) => { };
    onTouched = () => { };

    writeValue(value: any): void {
        this.value = value || "";
    }

    registerOnChange(fn: any): void {
        this.onChange = fn;
    }

    registerOnTouched(fn: any): void {
        this.onTouched = fn;
    }

    setDisabledState?(isDisabled: boolean): void {
        this.disabled = isDisabled;
    }

    handleInput(event: Event) {
        const value = (event.target as HTMLInputElement).value;
        this.value = value;
        this.onChange(value);
        this.onTouched();
    }
}
