// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function prevButton(currentIndex) {
    let currentDiv = document.getElementById(`question${currentIndex}`);
    currentDiv.hidden = true;
    currentIndex--;
    let prevDiv = document.getElementById(`question${currentIndex}`);
    prevDiv.hidden = false;
}

function nextButton(currentIndex) {

    let currentDiv = document.getElementById(`question${currentIndex}`);

    if (document.getElementById(`question${currentIndex + 1}`) != null) {
        currentDiv.hidden = true;
        currentIndex++;
        let nextDiv = document.getElementById(`question${currentIndex}`);
        nextDiv.hidden = false;
    }
}
// soru adedi parametre olarak geliyor
// function finishButton(lastIndex, userId) {
//     console.log(userId)
//     let i = 0;
//     let selectedValues = [];
//     while (i <= lastIndex) {
//         let groupValue = parseInt($(`input[name="flexRadioDefault${i}"]:checked`).val());
//         i++;
//         selectedValues.push(groupValue);
//     }
//     console.log(typeof userId);
//     console.log("userId:", userId);
//     // var data = { selectedValues: selectedValues, userIdFromJavaScript: userId };
//     $.ajax({
//         type: 'POST',
//         url: '/User/User/UserAnswers',
//         data: { selectedValues: selectedValues, userIdFromJavaScript: userId },
//         traditional: true, // This is important to send the array correctly
//         success: function (data) {
//             console.log(data);
//         },
//         error: function (xhr, status, error) {
//             console.error(error);
//         }
//     });
// }


