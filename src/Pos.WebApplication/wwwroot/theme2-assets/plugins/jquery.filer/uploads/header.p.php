<?php
global $zodkoo_setting;
?>
<?php
/**
 * The header for our theme
 *
 * This is the template that displays all of the <head> section and everything up until <div id="content">
 *
 * @link https://developer.wordpress.org/themes/basics/template-files/#template-partials
 *
 * @package WordPress
 * @subpackage Zodkoo
 * @since 1.0
 * @version 1.0
 */

?><!DOCTYPE html>
<html <?php language_attributes(); ?>>

<head>
	<meta charset="<?php bloginfo('charset'); ?>">
    <meta name="viewport" content="width=device-width, initial-scale=1">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
    <link rel="pingback" href="<?php bloginfo('pingback_url'); ?>">
    <?php if ( ! function_exists( 'wp_site_icon' ) ) { ?>
    	<?php $favicon = '';
            if (isset( $zodkoo_setting['favicon_logo'])) {
            $favicon = $zodkoo_setting['favicon_logo']['url']; ?>
            <link rel="shortcut icon" href="<?php echo esc_url($favicon); ?>">
        <?php } else { ?>
        <link rel="shortcut icon" href="<?php $logo_favicon_url = get_template_directory_uri() . '/assets/images/favicon.ico'; echo esc_url($logo_favicon_url); ?>">
        <?php } ?>
    <?php } ?>
	<?php wp_head(); ?>
</head>

<body <?php body_class(); ?> data-spy="scroll" data-target="#navbar-menu">

<!-- Navigation Bar-->
<header id="topnav" class="scroll-active defaultscroll">
<?php global $zodkoo_setting; ?>
	<div class="container">
		<!-- Logo container-->
		<div class="logo">
			<a href="<?php echo esc_url(get_site_url()); ?>">
				<?php $logo = '';
                if (isset( $zodkoo_setting['header_logo'])) { 
					$logo = $zodkoo_setting['header_logo']['url'];
				?>
					<img src="<?php echo esc_url($logo); ?>" alt="<?php echo esc_html__('logo','zodkoo') ?>" class="logo-light" height="30">
				<?php } else { ?>
                    <img src="<?php $logo_custom_url = get_template_directory_uri() . '/assets/images/logo.png'; echo esc_url($logo_custom_url); ?>" alt="<?php echo esc_html__('logo','zodkoo') ?>" class="logo-light" height="30">
                <?php  }  ?>
			</a>
		</div>
		<!-- End Logo container-->
		<div class="menu-extras">

			<div class="menu-item">
				<!-- Mobile menu toggle-->
				<a class="navbar-toggle">
					<div class="lines">
						<span></span>
						<span></span>
						<span></span>
					</div>
				</a>
				<!-- End mobile menu toggle-->
			</div>
		</div>

		<div id="navigation">

			<!-- Navigation Menu-->

			<!-- Navbar left -->
            <?php if (has_nav_menu('primary')) { ?>
				<?php wp_nav_menu( array( 'theme_location' => 'primary','depth' => '4','menu_class' => 'navigation-menu' ,'walker' => new zodkoo_Walker_Nav_Menu()) ); ?>
            <?php } ?>    
		</div>
	</div>
</header>
<!-- End Navigation Bar-->


<!--Bradcrumbs-->
<?php if(is_404() || is_category() || is_search() || is_archive() || is_month() || is_author()) { ?>
    <div class="zodkoo-breadcrumb">
            <div class="container">
                <div class="row breadcrumbs">                       
                    <div class="page_title">
                       <h2 class="heading_text"><?php if(function_exists('zodkoo_page_title_sections')){ echo esc_html(zodkoo_page_title_sections()); } ?></h2>
                    </div>
                    <div class="page_breadcrumb">                   
                        <?php if(function_exists('zodkoo_breadcrumbs')){ echo zodkoo_breadcrumbs(); } ?>
                    </div>
                </div>
            </div>
        </div>
<?php } else { ?>
<?php global $post;
      $checkboxBreadCrumbs = (get_post_meta( $post->ID, 'breadcrumbs-post-meta', 'yes' ) != '') ? get_post_meta( $post->ID, 'breadcrumbs-post-meta', 'yes' ) : ''; 
 ?>
<?php  if ( $checkboxBreadCrumbs == 'yes') { ?>
    	<div class="zodkoo-breadcrumb">
    		<div class="container">
    			<div class="row breadcrumbs">						
    				<div class="page_title">
    					<h2 class="heading_text"><?php if(function_exists('zodkoo_page_title_sections')){ echo esc_html(zodkoo_page_title_sections()); } ?></h2>
    				</div>
    				<div class="page_breadcrumb">					
    					<?php if(function_exists('zodkoo_breadcrumbs')){ echo zodkoo_breadcrumbs(); } ?>
    				</div>
    			</div>
    		</div>
    	</div>
<?php } elseif($checkboxBreadCrumbs == '' ) { 
    if(is_front_page() ) {  } else { ?>
        <div class="zodkoo-breadcrumb">
                <div class="container">
                    <div class="row breadcrumbs">                       
                        <div class="page_title">
                            <h2 class="heading_text"><?php if(function_exists('zodkoo_page_title_sections')){ echo esc_html(zodkoo_page_title_sections()); } ?></h2>
                        </div>
                        <div class="page_breadcrumb">                   
                            <?php if(function_exists('zodkoo_breadcrumbs')){ echo zodkoo_breadcrumbs(); } ?>
                        </div>
                    </div>
                </div>
            </div>
<?php  }  } } ?>
<!-- BredCrumbs -->