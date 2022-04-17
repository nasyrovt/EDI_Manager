import { Component, OnInit, ViewEncapsulation, Output, ViewChild } from '@angular/core';
import { MatDatepicker, MatDatepickerInputEvent } from '@angular/material/datepicker';

/** @title Date range picker with custom a selection strategy */
@Component({
  selector: 'app-series-date-picker',
  templateUrl: './series-date-picker.component.html',
  styleUrls: ['./series-date-picker.component.scss']
})
export class SeriesDatePickerComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }


  public CLOSE_ON_SELECTED = false;
  public init = new Date();
  public resetModel = new Date(0);
  public model: Date[] = [];
  @ViewChild('picker', { static: true })
  _picker: MatDatepicker<Date> | undefined;

  public dateClass = (date: Date) => {
    if (this._findDate(date) !== -1) {
      return ['selected'];
    }
    return [];
  }

  public dateChanged(event: MatDatepickerInputEvent<Date>): void {
    if (event.value) {
      const date = event.value;
      const index = this._findDate(date);
      if (index === -1) {
        this.model.push(date);
      } else {
        this.model.splice(index, 1)
      }
      this.resetModel = new Date(0);
      if (!this.CLOSE_ON_SELECTED) {
        if (!this._picker) { return; }
        const closeFn = this._picker.close;
        this._picker.close = () => { };
        // this._picker['_popupComponentRef'].instance._calendar.monthView._createWeekCells()
        setTimeout(() => {
          if (this._picker)
            this._picker.close = closeFn;
        });
      }
    }
  }

  public remove(date: Date): void {
    const index = this._findDate(date);
    this.model.splice(index, 1)
  }

  private _findDate(date: Date): number {
    return this.model.map((m) => +m).indexOf(+date);
  }
}
