///<reference path="../../Hypermedia.ts"/>
/// <reference path="oneoptiondialogcontroller.ts" />
/// <reference path="twooptionsdialogcontroller.ts" />

module Hypermedia {
    export class ErrorMessageDialogService {
        constructor(private confirmDialog: DialogService) {
        }

        showMessage = (message: any) => {
            var errorText = "";
            if (angular.isString(message)) {
                errorText = message;
            }
            else if (message.exceptionMessage) {
                errorText = message.exceptionMessage;
            }
            else
            {
                errorText = message.message ||"A error occured";
            }
            this.confirmDialog.openOneOptionDialog({
                title: "Error Message",
                content: errorText,
                confirmButtonText: "Ok",
                confirmEvent: () => { }
            });
        }
    }

    angular.module("Hypermedia").service("ErrorMessageDialogService", ["DialogService", ErrorMessageDialogService]);
}