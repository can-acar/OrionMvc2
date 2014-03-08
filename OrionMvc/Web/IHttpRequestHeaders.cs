using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace OrionMvc.Web
{
    public interface IHttpRequestHeaders : IHttpHeaders, IDictionary<string, string>
    {
        /// <summary>Gets or sets "Accept" header.</summary>
        /// <value>The "Accept" header.</value>
        /// <seealso cref="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html">W3C Header Field Definitions</seealso>
        string Accept
        {
            get;
            set;
        }

        /// <summary>Gets or sets "Accept-Charset" header.</summary>
        /// <value>The "Accept-Charset" header.</value>
        /// <seealso cref="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html">W3C Header Field Definitions</seealso>
        string AcceptCharset
        {
            get;
            set;
        }

        /// <summary>Gets or sets "Accept-Encoding" header.</summary>
        /// <value>The "Accept-Encoding" header.</value>
        /// <seealso cref="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html">W3C Header Field Definitions</seealso>
        string AcceptEncoding
        {
            get;
            set;
        }

        /// <summary>Gets or sets "Accept-Language" header.</summary>
        /// <value>The "Accept-Language" header.</value>
        /// <seealso cref="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html">W3C Header Field Definitions</seealso>
        string AcceptLanguage
        {
            get;
            set;
        }

        /// <summary>Gets or sets "Cache-Control" header.</summary>
        /// <remarks>
        /// 	<para>
        ///     The Cache-Control general-header field is used to specify directives that MUST be obeyed 
        ///     by all caching mechanisms along the request/response chain. The directives specify behavior 
        ///     intended to prevent caches from adversely interfering with the request or response. These 
        ///     directives typically override the default caching algorithms. Cache directives are 
        ///     unidirectional in that the presence of a directive in a request does not imply that the 
        ///     same directive is to be given in the response.
        ///     </para>
        /// 	<para>Possible values for the request "Cache-Control" header are:</para>
        /// 	<list type="#">
        /// 		<item><a href="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.9.1">no-cache</a></item>
        /// 		<item><a href="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.9.2">no-store</a></item>
        /// 		<item><a href="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.9.3">max-age</a></item>
        /// 		<item><a href="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.9.3">max-stale</a></item>
        /// 		<item><a href="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.9.3">min-fresh</a></item>
        /// 		<item><a href="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.9.5">no-transform</a></item>
        /// 		<item><a href="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.9.4">only-if-cached</a></item>
        /// 	</list>
        /// </remarks>
        /// <value>The "Cache-Control" header.</value>
        /// <seealso cref="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html">W3C Header Field Definitions</seealso>
        string CacheControl
        {
            get;
            set;
        }

        /// <summary>Gets or sets "Content-Disposition" header.</summary>
        /// <value>The "Content-Disposition" header.</value>
        /// <seealso cref="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html">W3C Header Field Definitions</seealso>
        string ContentEncoding
        {
            get;
            set;
        }

        /// <summary>Gets or sets "Content-Length" header.</summary>
        /// <value>The "Content-Length" header.</value>
        /// <seealso cref="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html">W3C Header Field Definitions</seealso>
        string ContentLength
        {
            get;
            set;
        }

        /// <summary>Gets or sets "Content-Type" header.</summary>
        /// <value>The "Content-Type" header.</value>
        /// <seealso cref="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html">W3C Header Field Definitions</seealso>
        string ContentType
        {
            get;
            set;
        }

        /// <summary>Gets or sets "If-Match" header.</summary>
        /// <value>The "If-Match" header.</value>
        /// <seealso cref="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html">W3C Header Field Definitions</seealso>
        string IfMatch
        {
            get;
            set;
        }

        /// <summary>Gets or sets "If-Modified-Since" header.</summary>
        /// <value>The "If-Modified-Since" header.</value>
        /// <seealso cref="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html">W3C Header Field Definitions</seealso>
        string IfModifiedSince
        {
            get;
            set;
        }

        /// <summary>Gets or sets "If-None-Match" header.</summary>
        /// <value>The "If-None-Match" header.</value>
        /// <seealso cref="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html">W3C Header Field Definitions</seealso>
        string IfNoneMatch
        {
            get;
            set;
        }

        /// <summary>Gets or sets "If-Range" header.</summary>
        /// <value>The "If-Range" header.</value>
        /// <seealso cref="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html">W3C Header Field Definitions</seealso>
        string IfRange
        {
            get;
            set;
        }

        /// <summary>Gets or sets "If-Unmodified-Since" header.</summary>
        /// <value>The "If-Unmodified-Since" header.</value>
        /// <seealso cref="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html">W3C Header Field Definitions</seealso>
        string IfUnmodifiedSince
        {
            get;
            set;
        }

        /// <summary>Gets or sets "User-Agent" header.</summary>
        /// <value>The "User-Agent" header.</value>
        /// <seealso cref="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html">W3C Header Field Definitions</seealso>
        string UserAgent
        {
            get;
            set;
        }

        /// <summary>Grabs the values from an instance of <see cref="NameValueCollection"/>.</summary>
        /// <remarks>
        /// <c>GetRequestValues</c> expects request keys to be named according to the
        /// <a href="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html">HTTP Header Field
        /// Definitions</a>.
        /// </remarks>
        /// <example>
        /// 	<code lang="CS">
        /// NameValueCollection request = new NameValueCollection();
        /// HttpHeaders headers = new HttpHeaders();
        ///  
        /// request["Content-Type"] = "text/plain";
        /// request["Content-Length"] = "10";
        ///  
        /// headers.GetRequestValues(request);
        ///  
        /// headers.ContentType   #=&gt; "text/plain"
        /// headers.ContentLength #=&gt; "10"
        ///     </code>
        /// </example>
        /// <param name="request">The ASP.NET request object.</param>
        void GetRequestValues(System.Web.HttpRequest request);
    }
}
