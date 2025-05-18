This is a playground repo to demonstrate how to integrate HTMX with Blazor SSR components for a server-side, 
yet interactive, application.

Each feature demonstrates a use-case of HTMX.

**Counter** demonstrates how to use an SSR page to render a static component on first load. 
Clicking a `Down` or `Up` button will trigger an API call which updates the counter and returns new HTML to be swapped 
in to replace the static markup. In addition, the API response contains a `HX-Trigger` header which triggers the same 
counter component in the page top bar to update as well.

**Weather** demonstrates how to do an HTMX load trigger which calls for markup when the page loads. 
I think for SSR, it makes more sense to do it like the Counter, but this was just a demo.

**Menu** demonstrates how a popup menu can work with dynamic content. I use a simple HTML `button` and `dialog` pair 
to show/hide the dialog while using and `hx-get` to fetch the menu content to put into the `dialog`.

**Cocktails** is a multi-level HTMX page which searches a remote API for cocktails. HTMX loads the search results and 
clicking a result loads the detail via HTMX. This uses `hx-swap-oob` to change some content when another piece changes.

**Photos** is a multi-component page which loads a selection of photos from Picsum based on the page number and size 
of page. It demonstrates how to use an `hx-trigger` to update the photos based on the values in the PhotosControl 
component. All values are persisted in session state.
