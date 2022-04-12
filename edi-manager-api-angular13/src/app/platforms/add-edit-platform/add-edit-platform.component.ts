import { PlatformsApiService } from './../../services/platforms-api.service';
import { Input, Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-add-edit-platform',
  templateUrl: './add-edit-platform.component.html',
  styleUrls: ['./add-edit-platform.component.scss']
})
export class AddEditPlatformComponent implements OnInit {

  platformsList$!: Observable<any[]>;

  constructor(public service: PlatformsApiService) { }


  @Input() platform: any;
  platformId: number = 0;
  platformName: string = "";

  ngOnInit(): void {
    this.platformId = this.platform.platformId;
    this.platformName = this.platform.platformName;

    this.platformsList$ = this.service.getPlatformsList();
  }

  addPlatform() {
    var platform = {
      platformName: this.platformName
    }

    this.service.addPlatform(platform).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if (closeModalBtn) {
        closeModalBtn.click();
      }

      var showAddSuccess = document.getElementById('add-platform-success-alert');
      if (showAddSuccess) {
        showAddSuccess.style.display = "block";
      }
      setTimeout(function () {
        if (showAddSuccess) {
          showAddSuccess.style.display = "none";
        }
      }, 4000);
    })
  }

  updatePlatform() {
    var platform = {
      platformId: this.platformId,
      platformName: this.platformName
    }
    var id: number = this.platformId;

    this.service.updatePlatform(id, platform).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if (closeModalBtn) {
        closeModalBtn.click();
      }

      var showUpdateSuccess = document.getElementById('update-platform-success-alert');
      if (showUpdateSuccess) {
        showUpdateSuccess.style.display = "block";
      }
      setTimeout(function () {
        if (showUpdateSuccess) {
          showUpdateSuccess.style.display = "none";
        }
      }, 4000);
    })
  }
}


