import { FileMimesApiService } from 'src/app/services/file-mimes-api.service';
import { FilesService } from 'src/app/services/files-api.service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { HttpEventType, HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-upload-file',
  templateUrl: './upload-file.component.html',
  styleUrls: ['./upload-file.component.scss']
})
export class UploadFileComponent implements OnInit {

  public progress: number | undefined;
  public message: string | undefined;

  @Output() public onUploadFinished = new EventEmitter();

  constructor(private http: HttpClient, private filesService: FilesService, private fileMimesService: FileMimesApiService) { }

  ngOnInit() {
  }

  public uploadFile = (files: FileList | null) => {
    if (!files || files.length === 0) {
      return;
    }
    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    
    //If file mime is not accepted
    if (this.getByValue(this.fileMimesService.fileMimesMap, fileToUpload.type.split("/")[1]) == -1) {
      this.message = "Can't upload file with this mime:" + fileToUpload.type.split("/")[1];
      this.progress = 0;
      return;
    }
    this.http.post('https://localhost:7255/api/upload', formData, { reportProgress: true, observe: 'events' })
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress && event.total)
          this.progress = Math.round(100 * event.loaded / event.total);
        else if (event.type === HttpEventType.Response) {
          this.message = fileToUpload.name;
          
          var file = {
            fileName: fileToUpload.name.split(".")[0],
            fileMimeId: fileToUpload.type.split("/")[1],
            size: fileToUpload.size
          };
          this.filesService.addFile(file);
          
          this.filesService.refreshFilesMap();
          this.onUploadFinished.emit(event.body);
        }
      });
  }

  getByValue(map: Map<number, string>, searchValue: string): number | undefined {
    for (let [key, value] of map.entries()) {
      if (value === searchValue)
        return key;
    }
    return -1;
  }

}
