const t=JSON.parse('{"key":"v-5b5819b9","path":"/frontend/portal-actions.html","title":"Portal Actions","lang":"en-US","frontmatter":{"title":"Portal Actions","category":"frontend","tag":["actions","favorites","settings"]},"headers":[{"level":2,"title":"Add New Action","slug":"add-new-action","link":"#add-new-action","children":[]},{"level":2,"title":"Portal Actions","slug":"portal-actions","link":"#portal-actions","children":[]},{"level":2,"title":"Top Bar Actions","slug":"top-bar-actions","link":"#top-bar-actions","children":[]},{"level":2,"title":"Actions Views","slug":"actions-views","link":"#actions-views","children":[]},{"level":2,"title":"State Handling","slug":"state-handling","link":"#state-handling","children":[]}],"git":{"createdTime":1692617290000,"updatedTime":1692617290000,"contributors":[{"name":"github-actions[bot]","email":"41898282+github-actions[bot]@users.noreply.github.com","commits":1}]},"readingTime":{"minutes":1.09,"words":328},"filePathRelative":"frontend/portal-actions.md","localizedDate":"August 21, 2023","excerpt":"<h2> Add New Action</h2>\\n<p>For a developer to add a new is fairly simple go to <code>portal-actions-config.ts</code> file and append a new PortalAction.</p>\\n<div class=\\"language-TS\\" data-ext=\\"TS\\"><pre class=\\"language-TS\\"><code>export interface PortalAction {\\n  actionId: string;\\n  name: string;\\n  icon: string;\\n  onClick?: VoidFunction;\\n  component?: FunctionComponent;\\n  widgetId?: string;\\n  appendDivider?: boolean\\n}\\n</code></pre></div>"}');export{t as data};
