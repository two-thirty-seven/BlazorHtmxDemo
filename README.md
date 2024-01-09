This is a playground repo which is being used to demonstrate how to integrate HTMX with Blazor SSR components for a server-side, yet interactive, application.

Each feature demonstrates a usage of HTMX.

**Counter** demonstrates how to use an SSR page to render a static component on first load. Then clicking the button will trigger an API call which updates the counter and returns new HTML to be swapped in to replace the static markup. In addition, the API response contains a HX-Trigger header which triggers the same counter component in the page top bar to update as well.

**Weather** demonstrates how to do an HTMX load trigger which calls for markup when the page loads. I think for SSR, it makes more sense to do it like the Counter, but this was just a demo.

**Menu** demonstrates how a popup menu can work. I use GET and PUT methods to map to open and closed states. The thinking was "I get a menu to display" and "I put the menu back".

**Cocktails** is a multi-level HTMX page which searches a remote API for cocktails. HTMX loads the search results and clicking a result loads the detail via HTMX.  

**Photos** is a multi-component page which loads a selection of photos from Picsum based on the page number and size of page. It demonstrates how to use an HX-Trigger to update the photos based on the values in the PhotosControl component. All values are persisted in session state.
