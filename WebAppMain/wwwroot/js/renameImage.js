$(document).ready(function () {

    yourForm.addEventListener("FormCampaign", ({ formData }) => {
        const file = formData.get("fileupload");
        formData.delete("fileupload");
        formData.append("fileupload", file, "ChangedName.tmp");
        alert("test");
    });
});