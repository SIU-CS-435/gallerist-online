//set all items with a non empty string as their title to use qtip
$('[title!=""]').qtip({
    position: {
        my: 'top left',
        at: 'bottom center',
        //target: 'mouse',
        adjust: {
            mouse: false 
        }
    },
    hide: {
        fixed: false,
        event: 'unfocus click mouseleave',
        delay: 0,
        leave: true
    },
    show: {
        delay: 1000
    },
    style: {
        classes: 'qtip-white qtip-shadow qtip-bootstrap'
    }
});

//this is a generic tooltip I am setting up that can be used for displaying help info on game board
$('.board-information-section').qtip({
    content:{
        text: function (event, api) {
            //we will ideally want to change how we pull the text and title but this is just a demo of how we can
            //pull from data attribute of hover'd item
            return $(this).attr('data-text');
        },
        title: function (event, api) {
            //pull from title of hover'd item (this is the default behavior)
            return $(this).attr('title');
        }
    },
    position: {
        my: 'center left',
        at: 'center right',
        target: 'mouse',
        adjust: {
            mouse: false
        }
    },
    hide: {
        fixed: true, //prevent from disappearing if you hover over it
        event: 'unfocus mouseleave',
        delay: 0,
        leave: true
    },
    show: {
        delay: 2000 //wait two seconds before showing help. We don't want to spam helps
    },
    style: {
        classes: 'qtip-white qtip-shadow qtip-bootstrap' //might want to choose different styles for help tooltips
    }
});