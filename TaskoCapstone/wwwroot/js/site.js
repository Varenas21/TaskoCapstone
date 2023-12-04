// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

const completeBtn = document.getElementById('completeBtn');
const taskId = parseInt(completeBtn.getAttribute('data-task-id'));



// Write your JavaScript code.
$("#completeBtn").click(function () {

    var result = confirm("Are you sure you want to complete this task?");
    if (result) {
        // Complete the task (set the database to true)
        // Will require API endpoint
        // Ajax is a way to send a request using POST
        

        $.ajax({
            url: '/api/tasks/complete',
            type: 'post',
            data: JSON.stringify({
                taskId: taskId
            }),
            // Redirect user to the task page
            success: function () {
                $('#sendButton').prop('disabled', false);
            },

            //Error message
            error: function () {
                alert("There was an error completing the task.");
            }
 
        });

    }

});

        