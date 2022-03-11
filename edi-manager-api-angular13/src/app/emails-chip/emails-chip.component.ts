import { COMMA, ENTER } from "@angular/cdk/keycodes";
import { Component, Output, EventEmitter } from "@angular/core";
import { MatChipInputEvent } from '@angular/material/chips';
import { DomSanitizer } from '@angular/platform-browser';
import { MatIconRegistry } from '@angular/material/icon';

const DELETE_ICON =
  `
  <svg xmlns="http://www.w3.org/2000/svg"  viewBox="0 0 48 48" width="48px" height="48px">
  <linearGradient id="hbE9Evnj3wAjjA2RX0We2a" x1="7.534" x2="27.557" y1="7.534" y2="27.557" gradientUnits="userSpaceOnUse">
  <stop offset="0" stop-color="#f44f5a"/>
  <stop offset=".443" stop-color="#ee3d4a"/>
  <stop offset="1" stop-color="#e52030"/>
  </linearGradient>
  <path fill="url(#hbE9Evnj3wAjjA2RX0We2a)" d="M42.42,12.401c0.774-0.774,0.774-2.028,0-2.802L38.401,5.58c-0.774-0.774-2.028-0.774-2.802,0	L24,17.179L12.401,5.58c-0.774-0.774-2.028-0.774-2.802,0L5.58,9.599c-0.774,0.774-0.774,2.028,0,2.802L17.179,24L5.58,35.599	c-0.774,0.774-0.774,2.028,0,2.802l4.019,4.019c0.774,0.774,2.028,0.774,2.802,0L42.42,12.401z"/>
  <linearGradient id="hbE9Evnj3wAjjA2RX0We2b" x1="27.373" x2="40.507" y1="27.373" y2="40.507" gradientUnits="userSpaceOnUse">
  <stop offset="0" stop-color="#a8142e"/>
  <stop offset=".179" stop-color="#ba1632"/>
  <stop offset=".243" stop-color="#c21734"/>
  </linearGradient><path fill="url(#hbE9Evnj3wAjjA2RX0We2b)" d="M24,30.821L35.599,42.42c0.774,0.774,2.028,0.774,2.802,0l4.019-4.019	c0.774-0.774,0.774-2.028,0-2.802L30.821,24L24,30.821z"/>
  </svg>
`;


@Component({
  selector: 'app-emails-chip',
  templateUrl: './emails-chip.component.html',
  styleUrls: ['./emails-chip.component.scss']
})
export class EmailsChipComponent {

  visible = true;
  selectable = true;
  removable = true;
  addOnBlur = true;
  readonly separatorKeysCodes: number[] = [ENTER, COMMA];

  @Output() 
  addingEventEmitter = new EventEmitter<string>();
  public emails: string[] = [];

  constructor(iconRegistry: MatIconRegistry, sanitizer: DomSanitizer) {
    iconRegistry.addSvgIconLiteral('delete', sanitizer.bypassSecurityTrustHtml(DELETE_ICON));
  }

  add(event: MatChipInputEvent): void {
    const input = event.input;
    const value = event.value;
    
    if ((value || "").trim()) {
      this.emails.push(value.trim());
      this.addingEventEmitter.emit(value);
    }

    // Reset the input value
    if (input) {
      input.value = "";
    }
  }

  remove(email: string): void {
    const index = this.emails.indexOf(email);

    if (index >= 0) {
      this.emails.splice(index, 1);
    }
  }

  @Output()
  public getEMailsList(): string {
    return this.emails.join(";");
  }
}
