package md5f6df9ff59e68d694a577a1fb08c63903;


public class CatalogAdapter_CatalogViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Project.Adapters.CatalogAdapter+CatalogViewHolder, Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CatalogAdapter_CatalogViewHolder.class, __md_methods);
	}


	public CatalogAdapter_CatalogViewHolder (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == CatalogAdapter_CatalogViewHolder.class)
			mono.android.TypeManager.Activate ("Project.Adapters.CatalogAdapter+CatalogViewHolder, Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
