$('[title!=""]').qtip({ //set all items with a non empty string as their title to use qtip
    position: {
        my: 'top left',
        at: 'bottom center',
        //target: 'mouse',
        adjust: {
            mouse: false 
        }
    },
    hide: {
        fixed: true, //without this hovering on the tooltip itself causes problems with mouseout not closing the tooltip until you mouse back in
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